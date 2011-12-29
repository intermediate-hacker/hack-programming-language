var x = "Hello!"
var y = "World!"

var hello = x+y

writeln hello

var test_num = 5
writeln "test number: {0}", test_num

// THIS IS A COMMENT
/* another damn comment 
   of multiple 
   lines */

while (true)
	write "Enter Name:"
	
	var name = readln
	if (name == "me")
		writeln "THIS IS SO AWESOME!!!"
		writeln "I am me!"
	end
	
	else if(name == "exit")
		writeln "Exiting..."
		exit 0
	end
	
	else
		writeln "NOO!!! :("
		write "I am not 'me'..."
	end
end
