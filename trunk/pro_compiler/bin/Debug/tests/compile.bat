@echo off
set /p pname=Enter Source:
call pro_compiler %pname%.hack
call csc %pname%.cs
set /p run=Run Y/N?
if run == "Y" then
start %pname%.exe		
pause