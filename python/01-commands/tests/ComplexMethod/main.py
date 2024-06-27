from search_in_directory import SearchInDirectory

reverse_dictionary = SearchInDictionary()

dimensions = {
    "1.0.5.6": 5,
    "12.4.5.6": 12,
}

result = reverse_dictionary.execute(dimensions, 12)
print(result)