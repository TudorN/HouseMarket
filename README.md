# HouseMarket
FUNDA Api call and data manipulation.

Solution Funda assignment 
Author: Tudor Nedelcu
Public repository:https://github.com/TudorN


The goal of the solution is to parse the json output of an api and render certain data in a table on a web page. The json data provided via the api contains information about the house market in Amsterdam. The request was to show the top 10 brokers listing the most houses with and without garden.

Api address:  http://partnerapi.funda.nl/feeds/Aanbod.svc/[key]/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25
Api key = ac1b0b1572524640a0ecc54de453ea9f



The solution contains 2 projects:
•	HouseMarket
•	HouseMarket.OfferService


HouseMarket project

This is an Asp.net core mvc project to which I've added the following:

Controllers:
•	HouseMarketOfferController

Models:
•	BrokerViewModel
•	TopBrokerItemViewModel
•	TopBrokerListViewModel

Views:
•	Index
•	_topBrokers











HouseMarketOfferController contains an action called Index which will build the BrokerViewModel and help render the top 10 brokers. It makes use of 4 services which are part of the HouseMarket.OfferService. These 4 services are injected via the constructer.(More information about these services is provided in the HouseMarket project description)

For evaluation purposes only, In case the api call fails the controller will build a model using sample data from 2 json files: Houses.json and HousesWithGarden.json. The json files contain the exact api data which was obtained first time the api was called successfully. The sample data is used for evaluation purposes only with awareness that in real life scenario(production) this would not be the case. This way the evaluator could still evaluate the solution in case the api call fails for whatever reason.  

The BrokerViewModel class instantiates and builds the class TopBrokerListViewModel. 
The TopBrokerListViewModel instantiates a list of TopBrokerItemViewModel.
The TopBrokerItemViewModel is a mirror of the Broker class which contains the BrokerId, name and the number of houses listed by that broker.

The view called index will render the 2 tables of top brokers by calling the partial view _topBrokers. It references the BrokerViewModel. The index view will also show the status of the Api call (successful or failed) at the top right corner. When the api call failes the page renders test data.
 
_topBrokers view references the TopBrokersListViewNodel and it contains a table for the top 10 brokers.


HouseMarket.OfferService project


This project contains the necessary means for calling and consuming the Api data.
It contains the following classes and interfaces:
 	 


For consuming the Api data the class called GenericApiCall was added. It contains a generic method for calling the api and deseriallizing the json into a generic object. The GenericApiCall will be injected via the interface into the HouseMarketOfferService class.

HouseMarketOfferService is responsible for building the url necessary for the api call and for returning the HouseMarketOffer object via the generic api call. This service is injected in the  HouseMarketOfferController via the controller.

HouseMarketDataSampleService is responsible for returning a data sample of type HouseMarketOffer. The sample data si retrieved by reading the json sample files (Houses.json, HousesWithGarden.json).This is done for evaluation purposes. This service is also injected in the  HouseMarketOfferController via the controller.

TopBrokerService is responsible for filtering and returning the top brokers with most listed house on funda. 
This service is also injected in the  HouseMarketOfferController via the controller.



	





