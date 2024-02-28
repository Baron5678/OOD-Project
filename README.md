OOD_24L_01175348

Ihor Kulynych ID:323695

Project Task 1 Loading and Serialization data

Goal: Load the data from the FTR file and serialize it into a JSON file.

Description and Commments:

Firstly, according ftr specification, classes are defined and all of them implements one interface <code>IPrimaryKeyed</code>.
It means each object from different source should be indetified by unique ulong value.
Objects stored in defined repositories according to their classes like for objects of class Cargo , there is CargoRepository
and those repositories implements <code>IRepository</code>. Each repository has property of type List which cantains respective 
objects. Also, all classes indentified by ClassID like ClassID of Cargo is "CA".

On the client side , there are dictionaries which are use for configuration of application.

Storage and definition of classes

One class or interface is defined in one .cs file, and .cs file name is the name of class or interface.

All class which store data called data classes which are in directory ./Data
All repositories where objects of class are stored are in directory ./Repository
All factories are in directory ./AbstractFactories
All readers are in directory ./StrategiesGettingData/DataReaders
All serializers are in directory ./DataSerializers
Application starts in Client.cs

Loading

Reading FTR and creating instances of objects which properties initialized by values from FTR file
Strategy pattern is used for implementing readers, which parse files of different format and 
instantiate the objects of defined classes, which implements interface <code>IRead</code>

As the first source file is FTR format, class FTRReader are defined. 
This reader accepts dictionary of repositories, factories and path which define file to be read. 
Method Read() read each line of text and as it is FTR file , all values are separated by commas, 
the line is splitted by commas and list of strings are received(this list called atomicVals) and 
passed as argument of method Create(). Additionally, the order of fields are defined accorrding 
to the order of values in FTR file. There are array values which kept by list of array strings after reading a line and
passed as another arguments of method Create(). In FTR file, arrays are surrounded with square brackets and 
elements of arrays splitted by semicolon.  

In the client, paths store in the ReaderPaths list, where we can configure path in the list.
All readers store in dictionary where value is concrete reader and key is format to read.
Files to be read are in directory ./DataFiles/Source.

Creating of instances of objects
Factory method pattern is used for creating new classes, also Abstract Factory also involved into instantiating of objects
All factories implements interface <code>IFactory</code> and contain single method 
<code>IPrimaryKeyed Create(List<string> atomicVals, List<List<string>> arrayVals)</code>
Each factory name follows such convention (Class name)Factory, so for Cargo there is CargoFactory

In the method, constructors of classes are called filling them with values from a atomicVals for non-array properties
and arrayVals for non-atomic properties.
In the client, all factoies stored in dictionaries where value is Concrete factory, and key is ClassID of object to be created.

Serialization

Visitor design pattern is used for serialization of data in repository, so repository are elements to be visisted by 
<code>JSONSerialzer</code> visitor which implemets <code>ISerializer</code> which contains overloaded method Serialize() 
accepting concrete repository which data is serialized. All repositories have property SerializeFormat to indicate in
which format to serialize objects(e.g YAML, JSON, XML), and they implements method SerializeRepository(), which accepts visitor 

In client, it is possible to indicate where to allocate serialzed objets by path, so there is dictionary JSONPaths, where 
value is path to allocate JSON file and key is ClassID, also convention for name of serialized files follows:  (ClassName).json.
Currently, all serialized data is kept in ./DataFiles/JSON. 




