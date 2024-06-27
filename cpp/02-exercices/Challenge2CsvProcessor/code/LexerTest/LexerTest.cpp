#include "pch.h"
#include "CppUnitTest.h"
import Lexer;

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LexerTest
{
    TEST_CLASS(LexerTest)
    {
    public:
        
        TEST_METHOD(EmptyString_ReturnsEOL)
        {
            Lexer lexer("");
            Assert::AreEqual((int)Lexer::Token::EndOfLine, (int)lexer.NextToken());
            Assert::AreEqual((int)Lexer::Token::EndOfLine, (int)lexer.NextToken());
        }

        TEST_METHOD(SingleComma_ReturnsFieldSeparatorAndEOL)
        {
            Lexer lexer(",");
            Assert::AreEqual((int)Lexer::Token::FieldSeparator, (int)lexer.NextToken());
            Assert::AreEqual((int)Lexer::Token::EndOfLine, (int)lexer.NextToken());
        }

        //TODO1: Add test methods below and let Copilot generate the code for you.
        //TEST_METHOD(MultipleCommas_ReturnsSameApuntOfFieldSeparatorsAndEOL)
        //TEST_METHOD(FieldsWithEmbeddedSpaces_ReturnsValuesAndEOL)
        //TEST_METHOD(DoubleQuotedFieldsInRawString_ReturnsDoubleQuotesAndFieldsAndEOL)
        //TEST_METHOD(DoubleQuotedFieldsWithEscapedDoubleQuotesInRawString_ReturnsDoubleQuotesAndFieldsAndEOL)

        //TODO2: Add test methods for additional scenarios below and let Copilot generate the code for you.
    };
}
