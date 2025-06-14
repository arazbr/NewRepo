Virastyar 1.3.1 
Copyright � 2011 SCICT 

==========================
Virastyar is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Virastyar is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Virastyar.  If not, see <http://www.gnu.org/licenses/>.


WHAT IS VIRASTYAR?
==========================
Virastyar is an open-source Microsoft� Office Word Add-in written in C#.
The following functionalities are provided by Virastyar:
	- Persian Spell Checking
	- Pinglish Conversion
	- Persian Character Normalization
	- Number, Date and Calendar Conversion
	- And many more...
	
The functionalities are available both through the Virastyar add-in interface,
and the accompanied class libraries.

More information is available at http://www.virastyar.ir/


BUILDING VIRASTYAR
==========================
You need the following to successfully build and run Virastyar from sources:
	- Microsoft� Visual Studio 2008 
	- Microsoft� Visual Studio Tools for Office
	- Microsoft� Office 2003 or Later
	- PowerShell
	
There is an automated build script provided. To use it, run "buildenv.bat" and 
execute "msrebuild.bat".

Alternatively, if you wish to run Virastyar from source files, you can open
"VirastyarLibs.sln", and build the required libraries. Then according to your
operating system and Microsoft Office version, change the directory to 
"VirastyarWordAddin" and open the "VirastyarWordAddin.sln" solution file 
(or VirastyarWordAddin2010.sln in case of 64-bit Office).

Also, you may need to change the ExecutionPolicy of the Powershell to build the Add-in successfully. 
To do this, start a PowerShell console as administrator, and run this command:
 >>Set-ExecutionPolicy Unrestricted
 
Warning: This command changes the default script execution policy on your machine.
For more information, see this link:
http://technet.microsoft.com/en-us/library/dd347628.aspx

REPORT BUGS & ISSUES
==========================
Development questions, suggestions and bugs should be sent to virastyar@scict.ir


CREDITS
==========================
Virastyar is produced by Supreme Council for Information and Communication Technology (SCICT).

Developers of Virastyar:
- Omid Kashefi, kashefi@{ieee.org, iust.ac.ir}
- Mehrdad Senobari, senobari@gmail.com
- Sina Iravanian, sina@sinairv.com
- Kamiar Kanani, kanani@ce.sharif.edu
- Mitra Nasri, mitra.nasri@ut.ac.ir
- Mohammad Hedayati, mhedayati@ce.sharif.edu
- Alireza Dehlaghi, dehlaghi@ce.sharif.edu
- Mohammad Sadegh Rasooli, rasooli@comp.iust.ac.ir
