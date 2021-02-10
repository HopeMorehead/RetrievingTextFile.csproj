# RetrievingTextFile.csproj

Recieving Text files and using string manipulation
wait for file to run. Two columns of words are generated.
Both with headers.If need be press the enter button to generate second list 
This is a program in the language of your choice which reads in a text file,
removes stop words (see explanation below), removes all non-alphabetical text, 
stems words into their root form (see explanation below), computes the frequency of each term,
and prints out the 20 most commonly occurring terms (not including stop words) in descending order of frequency. 


• Stemming algorithm. You will need to apply a standard stemming algorithm in order to stem all words to a morphological root 
(for example: jumping, jumps, jumped -> jump). 
You should use Porter Stemmer algorithm. Support for most languages can be found here: https://tartarus.org/martin/PorterStemmer/
