PubChem.NET
===========

.NET Wrapper for the [PubChem PUG REST API](https://pubchem.ncbi.nlm.nih.gov/pug_rest/PUG_REST.html)

[![Build Status](https://travis-ci.org/alfg/PubChem.NET.svg?branch=master)](https://travis-ci.org/alfg/PubChem.NET)

### Quick Start
Install the [NuGet package](https://nuget.org/packages/PubChem.NET/) from the package manager console:

```powershell
Install-Package PubChem.NET
```
In your application, call:

```CSharp
PubChemManager pc = new PubChemManager();

// Make an API call
var data = pc.GetCompoundDescription(1983);

Console.WriteLine(data.CID);
Console.WriteLine(data.Title);
Console.WriteLine(data.DescriptionURL);

// 2244
// Acetaminophen
// //www.ncbi.nlm.nih.gov/mesh/68000082
```

### Notes
This library is still under early development. Some details may change without notice. Feel free to contribute.

### Status
API Progress

- Compound 20%
- Substance 0%
- Assay 0%


### License
MIT License
