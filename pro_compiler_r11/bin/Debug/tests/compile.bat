@echo off
set /p pname=Enter Source:
call pro_compiler %pname%.hack
call csc %pname%.cs

echo Press enter to run program
pause > nul

:run
start %pname%.exe		

:end
pause