# AGENTS.md

Guidance for AI agents and human contributors working in this repository.

## Language Policy (durable rule)

**All first-party content in this repository must be written in English.**

This applies to:

- Every README and other documentation file (`README.md`, docs, guides).
- All source code: identifiers (functions, classes, variables, modules),
  comments, docstrings, and developer-facing log/diagnostic messages.
- Commit messages.

Do not introduce new Polish (or other non-English) text anywhere in the repo.
When touching existing code or docs that still contain non-English text,
translate it to English as part of your change.

Exceptions:

- End-user-visible UI strings may remain localized only when explicitly
  intended for end users. Developer-facing diagnostics, logs, and errors are
  always English.
- External serialized strings and wire contracts must not be renamed: the XML
  element/attribute names (`troop`, `charge`, `depression`, ...) and the MySQL
  table/column names derived from them are a fixed data contract.

## Code conventions

- Classic Windows Forms project using the non-SDK `.csproj` format; new source
  files must also be added to `WindowsFormsApp_ParserXMLtoDatabase.csproj`.
- Never hand-edit generated files: `*.Designer.cs`, `*.resx`,
  `Properties/*.settings`.
- Do not hard-code credentials in source; move connection strings to
  `App.config` when touching that code.
- SQL is built by string concatenation with parameters for values only; prefer
  fully parameterized statements when refactoring.

## Verification before delivery

- Build the solution (Visual Studio or MSBuild) after code changes.
- Run `git diff --check` to catch whitespace errors.
- No commit or push unless explicitly requested.
