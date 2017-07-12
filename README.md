# UmbracoCustomizations

## Roadmap

  - ~~DataType: Property picker~~ - done
  
	- just like how macro property picker work
  - Events Widget 
  
	- with downloadable .ics. this is based on http://www.vissit.com/projects/eventCalendar/
  - ~~DataType: Notes~~ - done
  
	- like uComponent Notes (is it possible to not add it as a DB entry in umbraco? it takes up DB space for something not needed to be saved multiple times)
	- use built in markdown umbraco so we don't have to introduce a new .js library just for this. 
	- hide toolbar. use ng-hide. cannot find documentation for hiding bar
  - DataType: Autogenerate 
  
	- random guid, random number, incremental number (do we really need this?)
  - ~~DataType: Create (readonly) value~~ - done
  
	- Readonly string we can use that can hold values that is applicable to all pages. E.g. css-classes. 
	  This has to be taken into a lot of consideration because at the beginning it will create this value in all pages. 
	  Then if updated, it also updates all. Uses alias **DTCustomCreateValue**. Please do not confuse with DTCustomReadonly
  - ~~DataType: Textbox with maxlength~~ - done
  
	- Textbox with maxlength, isrequired and regex validation
  - Place project as umbraco package. 
  
	- (Create actual data type entry in .cs so users dont have to create it.)

## Version 0.2 - 2017-July-10
  - DataType: Create (Readonly) type. This has to be used with careful consideration. Please read info above
  - DataType: Customized textbox with maxlength
  
## Version 0.1 - 2017-June-08
  - DataType: Property Picker
  - DataType: Notes
