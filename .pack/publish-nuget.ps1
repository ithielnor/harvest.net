# http://www.jeremyskinner.co.uk/2011/01/12/automating-nuget-package-creation-with-msbuild-and-powershell/

Function Get-DropBox() {
  $hostFile = Join-Path (Split-Path (Get-ItemProperty HKCU:\Software\Dropbox).InstallPath) "host.db"
  $encodedPath = [System.Convert]::FromBase64String((Get-Content $hostFile)[1])
  [System.Text.Encoding]::UTF8.GetString($encodedPath)
}

$scriptpath = split-path -parent $MyInvocation.MyCommand.Path

$dropbox = Get-DropBox
$keyfile = "$dropbox\Personal\nuget-key.txt"
$nugetpath = resolve-path "$scriptpath/nuget.exe"
$packpath = resolve-path "$scriptpath/*.nupkg"
$archivepath = resolve-path "$scriptpath/archive"
$specpath = resolve-path "$scriptpath/../Harvest.Net"
 
if(-not (test-path $keyfile)) {
  throw "Could not find the NuGet access key at $keyfile. If you're not the project owner, you shouldn't be running this script!"
}
else {  

  if (test-path $packpath) {
    # archive old packages
    move-item $packpath $archivepath
  }

  popd # up to root
  pushd $specpath

  # package it up
  & $nugetpath pack "Harvest.Net.csproj"
  move-item *.nupkg $scriptpath

  popd # up to root
  pushd $scriptpath
 
  # get our secret key. This is not in the repository.
  $key = get-content $keyfile
 
  if (test-path "*.nupkg") {
    # Find all the packages and display them for confirmation
    $packages = dir "*.nupkg"
    write-host "Packages to upload:"
    $packages | % { write-host $_.Name }
 
    # Ensure we haven't run this by accident.
    $yes = New-Object System.Management.Automation.Host.ChoiceDescription "&Yes", "Uploads the packages."
    $no = New-Object System.Management.Automation.Host.ChoiceDescription "&No", "Does not upload the packages."
    $options = [System.Management.Automation.Host.ChoiceDescription[]]($no, $yes)
 
    $result = $host.ui.PromptForChoice("Upload packages", "Do you want to upload the NuGet packages to the NuGet server?", $options, 0) 
 
    # Cancelled
    if($result -eq 0) {
      "Upload aborted"
    }
    # upload
    elseif($result -eq 1) {
      $packages | % { 
          $package = $_.Name
          write-host "Uploading $package"
          & $nugetpath push $package $key
          write-host ""
      }
    }
  }
  else {
    write-host "No packages found"
  }
  popd
}