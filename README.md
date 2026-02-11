## Running Your Tests
`dotnet test`  - This runs all tests
`HEADED=1 dotnet test` - This runs all tests with browser open
`dotnet test --filter [testfilename]` - This runs a specified test

## Code Gen
```
dotnet tool run playwright codegen https://www.stampinup.com
```

## How to clean up your directory view
If `bin` and `obj` folders are cluttering your workspace in VS Code and you find them distracting, you can "hide" them from the sidebar without deleting them:

1. Go to Code > Settings.

2. Search for "Files: Exclude".

3. Add patterns for **/bin and **/obj.

## Git Repository

### Create a Repository

1. Log in to your GitHub account.
2. Click **New Repository**.
3. Name your repository and follow the instructions on GitHub.

---

### Create a New Repository from the Command Line

```bash
echo "# test" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/abnerAlexis/test.git
git push -u origin main. 
```
### After updating your project;
```bash
git status
```
```bash
git add . //or git add filename
```
```bash
git commit -m "Short and meaningful message"
```
```bash
git push -u origin main
```
