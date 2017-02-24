# DexCMS.Core

## You have just stumbled upon a superbly early version of a .Net CMS, right now it is an 
aggregation of shared code across several small websites. Soon it will be awesome, right now, it's in progress. :)

## DexCMS.Core Development Rules
* This library is for generic code needed by all other libraries.
* It contains 3 libraries:
	* DexCMS.Core
		* For code not specific to mvc, webapi, etc.
	* DexCMS.Core.Mvc
		* For code specific to MVC sites
	* DexCMS.Core.WebApi
		* For code specific to WebApi sites
* These libraries can depend on NO other libraries in the framework.
* Before submitting a pull request, be sure you have installed the node packages and build the project in Release.
    * This includes the compiled dll into a /dist/ folder that consuming applications can use if I cut a new version off of your pull request.

##
* Client
	* Added sass to the build task
	* Added cachebusting for any files specified options.cacheBustFiles which uses the options.versionSuffix
	* Added implementation for grunt uglify to process the dex cms applications files
	* Added symlink options

## 0.7.0-alpha
* Model Mapping

## 0.5.1-alpha
* Mvc
** Fixed casing of Error route

## 0.5.0-alpha
* Another version ready to go

## 0.4.0-alpha
* Reworked Initializers

## 0.3.1-alpha
* Fixed bug with control panel navigation not in a sorted order.

## 0.3.0-alpha
* Added user management components

## 0.2.0-alpha
* Many improvements and bug fixes (yay alpha versions!)

## 0.1.1-alpha
* Removed duplicate route

## 0.1.0-alpha
* Initial Build
