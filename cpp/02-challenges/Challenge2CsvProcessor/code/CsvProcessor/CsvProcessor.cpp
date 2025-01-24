// CsvProcessor.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
//TODO1: Use /doc to document the file.

#include <iostream>
#include <fstream>
#include <filesystem>
#include <format>
#include <string>
//TODO2: Select the next two import lines and use /explain.
import Lexer;
import Parser;

namespace fs = std::filesystem;

int main(int argc, char* argv[])
{
    // Check number of arguments. At least a file name is required, several file names are supported.
    //TODO3: Press ENTER after this comment and let Copilot generate the code for you.

    //TODO4: Select the entire for loop and tell Copilot to "add comments to the selected code".
    for (int pos = 1; pos < argc; pos++)
    {   
        std::string_view filename = argv[pos];
        if (!fs::exists(filename))
        {
            std::cout << std::format(R"(WARNING: File "{}" does not exist. Skipping...)", argv[pos]) << std::endl;
            continue;
        }

        if (fs::is_directory(filename))
        {
            std::cout << std::format(R"(WARNING: "{}" is a directory. Skipping)", argv[pos]) << std::endl;
            continue;
        }

        std::ifstream file(argv[pos], std::ios::in);
        if (!file.is_open())
        {
            std::cout << std::format(R"(WARNING: Could not open file "{}")", argv[pos]) << std::endl;
            continue;
        }

        std::string line;
        while (std::getline(file, line))
        {
            std::cout << line << std::endl;
            Parser parser(line);

            while (parser.NextField())
            {
                std::cout << std::format("[{}] ", parser.Value());
            }
            std::wcout << std::endl;

            if (parser.Error())
            {
                std::cout << std::format("ERROR: {}", parser.ErrorMessage()) << std::endl;
            }

            std::cout << std::endl;
        }

        file.close();
    }

    return 0;
}

