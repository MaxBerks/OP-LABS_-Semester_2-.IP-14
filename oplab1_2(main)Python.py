import modules

# Variable with name of files
input_file = 'input.txt'
output_file = 'output.txt'

# Create input.txt
modules.create_input_file()
modules.read_txt_file(input_file)

# Change content of input file
input_content = modules.content_file(input_file)
output_content = modules.create_new_content(input_content)

# Save content to output file
modules.create_output_file(output_file, output_content)
modules.read_txt_file(output_file)
