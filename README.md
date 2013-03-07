# CropManager #


CropManager is a school project that offers solution for agricultural consultants to maintain data
about crops and fields. Solution also provides useful information by presenting users weather
information and twitter feeds.

Project consist of the server side database
(MS SQL 2012) and web services (Azure WCF
project), and of the client side (WP7 and Android phone application).

Database stores the data of clients’ applications via SQL stored procedures.

Azure WCF project provides WCF Rest web services for storing and managing data that are
used by clients applications.

Both mobile applications (WP7 and Android) offers the same set of functionalities:


**1. CropManager:**

- Add crop - adds data about some crop


- Remove crop - remove specific crop


- View crop details - presents info about crop and field on which it was planted


- Add field add - data about field and pinpoint the area of the field on the map



- View field details - preview field data and present field area on the map


**2. Journal:**



- Write journal record - write short description about crop observation


- Read journal records - read all journal records about some crop



**3. Notifications/Tasks:**



- View twitter feed for specific username - we can find latest feeds (prototype of incoming tasks solution)


**4. Weather:**


- Weather client previews - current weather forecast and weather forecast for next three days (for specific city and country)

For more details about architecture and application mockup, you can reference to diagrams in /docs
directory.
