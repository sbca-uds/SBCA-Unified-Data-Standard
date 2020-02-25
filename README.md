# Welcome to the SBCA Unified Data Standard Repository

# What is the SBCA Unified Data Standard?

The SBCA Unified Data Standard is developed by [SBCA](https://www.sbcindustry.com/). It's purpose is to provide a standard data model for the interoperability of machinery and software that are involved in the building, designing, shipping and quality control of structural building components and their connecting hardware, as well as other related information in the structural building component industry. 

# What is a Data Standard?

From Wikipedia: "A standard data model or industry standard data model (ISDM) is a data model that is widely applied in some industry, and shared amongst competitors to some degree. They are often defined by standards bodies, database vendors or operating system vendors.

When in use, they enable easier and faster information sharing because heterogeneous organizations have a standard vocabulary and pre-negotiated semantics, format, and quality standards for exchanged data. The standardization affects software architecture as solutions that vary from the standard may cause data sharing issues and problems if data is out of compliance with the standard.

Effective standard models have been developed in the banking, insurance, pharmaceutical and automotive industries, to reflect the stringent standards applied to customer information gathering, customer privacy, consumer safety, or just in time manufacturing."

# Examples of other industries that have Data Standards:

* [IFC (Industry Foundation Classes)](https://technical.buildingsmart.org/standards/ifc/)
* [ISO 10303](https://en.wikipedia.org/wiki/ISO_10303)

# What is in the SBCA Unified Data Standard?

The UDS contains the Facts of the Truss and the data required by Digital QC.

The Facts of the Truss are comprised of General information about a component

 - Name
 - Number of plies
 - Creation Program
 - Creation Timestamp
 - ComponentUsage (Roof, Floor, etc)
 - A component’s Members
   - Name
   - Material
   - Geometry
   - Member Type (Top Chord, Bottom Chord, etc)
   - Stock Length
   - Is or is not Field Installed
 - A component’s Connectors
   - Name
   - Material
   - Geometry
   - Is or is not Field Installed
 - A component’s Bearings
   - Name
   - Material
   - Geometry
   - A component’s Installation Hardware (Hangers, etc)
   - Name
   - Material
   - Geometry

The Data required by Digital QC is comprised of
 - Plate Information
 - Placement Tolerance Polygons
 - Teeth per Square Inch
 - Minimum Rotation Tolerance 
 - Maximum Rotation Tolerance
 - Area Method Used for evaluation (Gross or Net Area)
 - A component’s Plate-Member Contact Areas
   - Required Teeth
   - Required Plate Contact Area
   - JSI


# Who maintains and develops the SBCA Unified Data Standard?

While SBCA manages and approves the changes and development of this standard, input and pull requests are welcome from any interested parties. If this is your first time using github, [here](https://www.youtube.com/watch?v=w3jLJU7DT5E) is a short explanation video. For more information on the process of pull requests check out [this tutorial](https://help.github.com/articles/about-pull-requests/)