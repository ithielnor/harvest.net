Harvest.Net
===========

[![Build Status](https://travis-ci.org/ithielnor/harvest.net.svg?branch=master)](https://travis-ci.org/ithielnor/harvest.net)

A .Net wrapper for the [Harvest API][1].

Installation
------------

This library is hosted as a [nuget package][2].

To install Harvest.Net, run the following command in the Package Manager Console

    PM> Install-Package Harvest.Net

Usage
-----

Create a client object:

    HarvestRestClient client = new HarvestRestClient("example", "myusername", "mypassword");

Harvest API end points are converted to PascalCase. So `example.harvestapp.com/account/who_am_i` becomes

    Account myAccount = client.WhoAmI();

[1]:https://github.com/harvesthq/api
[2]:https://www.nuget.org/packages/Harvest.Net/
