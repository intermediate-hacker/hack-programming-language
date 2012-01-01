#define MY_MESSAGE msg	

Main:

	write "Enter Message: "
	var msg = readln
	
#__csc__
		System.Windows.Forms.MessageBox.Show(MY_MESSAGE);
#__end__
	
	writeln "Enter 'exit' to exit"
	var rtn = readln;
	
	if(rtn != "exit")
		goto Main;
	end
