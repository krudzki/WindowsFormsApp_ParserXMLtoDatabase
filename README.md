# WindowsFormsApp_ParserXMLtoDatabase

A Windows Forms utility (C#, .NET Framework) that loads a structured XML file,
creates matching tables in a MySQL database, and inserts the parsed content.
A secondary dialog (`F_DatabaseView`) shows the `information` table in a grid
and allows editing rows.

> Note: the repository/project name is historical and kept for continuity; all
> code content is in English.

## How it works

1. **Load XML into database** — pick an XML file; `CL_Parser` parses elements
   (`troop`, `sight`, `density`, `bible`, `historian` and their children),
   recreates one MySQL table per element type, and inserts every record.
2. **View database** — opens the database view form with a data grid for the
   `information` table plus insert/update/delete buttons and a table selector.

The XML schema is fixed (attribute names such as `charge`, `cucumber`,
`depression`, `waterfall` are literal XML attribute/table/column names —
these are serialized contract strings, not prose).

## Project structure

- `WindowsFormsApp_ParserXMLtoDatabase.sln` — Visual Studio solution.
- `WindowsFormsApp_ParserXMLtoDatabase/`
  - `Program.cs` — entry point.
  - `Form1.cs` / `Form1.Designer.cs` — main form with the load/view actions.
  - `F_DatabaseView.cs` / `F_DatabaseView.Designer.cs` — database viewer form.
  - `CL_Parser.cs` — XML parsing plus MySQL DDL/DML execution.
  - `CL_XMLtoDatabase.cs` — unused helper skeleton.
  - `Model_XML/CL_XMLmodel.cs` — POCO classes mirroring the XML structure
    (`Root`, `Troop`, `Oil`, ...).
  - `Properties/` — assembly info and generated settings/resources.

## Configuration

Set `XML_PARSER_MYSQL_CONNECTION_STRING` in the process environment before starting the application. The connection string is intentionally not stored in source control.

## Requirements

- .NET Framework with the MySQL Connector/Net assembly
  (`MySql.Data`), referenced by the classic non-SDK `.csproj`.
- A reachable MySQL server.

## Build

Visual Studio: open `WindowsFormsApp_ParserXMLtoDatabase.sln` and build.

Command line (Windows):

```bat
msbuild WindowsFormsApp_ParserXMLtoDatabase.sln /p:Configuration=Debug
```

## Language policy

All first-party content in this repository is written in English:
identifiers, comments, docstrings, developer-facing diagnostics, documentation,
and commit messages. XML attribute/element names and database table/column
names are serialized contracts and are not renamed. Generated files
(`*.Designer.cs`, `.resx`) are not edited by hand.

See [AGENTS.md](AGENTS.md) for the full contribution policy for AI agents and
human contributors.
