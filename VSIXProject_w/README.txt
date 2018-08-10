Let us mention that the following instructions are for windows 10!

How to INSTALL the extention on visual studio:
1. Install the extension by double-clicking "VSIXProject_w\VSIXProject_w\bin\Release\VSIXProject_w.vsix"

2. Open visual studio.

3. Open a dafny file you would like to use the extention on.

4. Choose a tool from the extention and use it (e.g. menu -> Refactoring -> Introduce local variables).

5. An error will pop-up saying "Could not find 'C:\Users\USER\AppData\Local\Microsoft\VisualStudio\14.0\Extensions\xxx.yyy\DanfnyPrelude.pbl'".

6. Copy the file "DanfnyPrelude.pbl" which is located in the path "VSIXProject_w\VSIXProject_w\bin-dafny" to the path "C:\Users\USER\AppData\Local\Microsoft\VisualStudio\14.0\Extensions\xxx.yyy" (Note that "C:\Users\USER\AppData" is a hidden directory).

ATTENTION - the path "C:\Users\USER\AppData\Local\Microsoft\VisualStudio\14.0\Extensions" exists but the correct directory "xxx.yyy" (there are few more directories like that) is been created during the installation of the extention and each time it's name changes(!). So, We cannot predict the directory name beforehand. We can know the exact name only after the first attempt of executing the extention when then, an error dialogBox prompts which says that "DanfnyPrelude.pbl" is missing in the directory mentioned above.

7. Restart visual studio and the extension is supposed to work fine from now on.




How to REMOVE the extension from visual studio:
1. Open visual studio
2. Go to Tools -> Extentions and Updates...
3. Select "Dafny refactoring project"
4. Press 'Uninstall'
5. Restart visual studio



How to MODIFY the extention:
1. Open the project on visual studio by double-clicking "VSIXProject_w\VSIXProject_w.sln".

2. search for the file devenv.exe in all drives (C:, D:, etc.) and change output path in visual studio in BOTH Release(!) and Debug(!) configurations to it's path (one-time step).
For example:
If my "devenv.exe" is located in "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE", then in visual studio go to Project -> VSIXProject_w Properties... -> Debug. Change the path in 'Start external program' to
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe" in both Release and Debug configurations.

3. Build the project (one-time step):
At the menu bar press Build -> Build VSIXPoject_w.
This act will create the directory "C:\Users\USER\AppData\Local\Microsoft\VisualStudio\14.0Exp".

4. Add the file "VSIXProject_w\VSIXProject_w\bin-dafny\DafnyPrelude.bpl" to the path "C:\Users\USER\AppData\Local\Microsoft\VisualStudio\14.0Exp\Extensions\Maria & Alon\Dafny refactoring project\1.0" (one-time step).

5. Modify the extention however you want.

6. See the result of the modification by pressing 'Start' which will open a new window of visual studio with the extention (called 'refactoring') in the menu bar. then, open a dafny file and place the cursor where you would like execute the extention at. Finally, press 'refactoring' from the menu bar and choose the tool you wish to use.


How to OPEN the project of the extention:
Double-click on VSIXProject_w\VSIXProject_w.sln


How to run all the tests of the project:
1. Open the project on visual studio by double-clicking "VSIXProject_w
2. choose menu -> Test -> Run -> All Tests (or type Ctrl+R,A)