OOD_24L_01175348

<<<<<<< HEAD
Ihor Kulynych ID:323695

Project Task 1 Loading and Serialization data

Goal: Load the data from the FTR file and serialize it into a JSON file.

Description and Commments:

Firstly, according ftr specification, classes are defined and all of them implements one interface <code>IPrimaryKeyed</code>

```csharp
public interface IPrimaryKeyed
{
	 ulong ID { get; set; }
}
```
