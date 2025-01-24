#include "pch.h"
#include "CppUnitTest.h"
import Parser;

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace ParserTest
{
    TEST_CLASS(ParserTest)
    {
    public:
        
        TEST_METHOD(EmptyString_ReturnsAnEmptyFieldWithoutError)
        {
            Parser parser("");
            Assert::IsTrue(parser.NextField());
            Assert::IsFalse(parser.Error());
            Assert::AreEqual("", parser.Value().c_str());
            Assert::IsFalse(parser.NextField());
            Assert::IsFalse(parser.Error());
        }

        TEST_METHOD(SingleComma_ReturnsTwoEmptyFieldsWithoutError)
            {
            Parser parser(",");
            Assert::IsTrue(parser.NextField());
            Assert::AreEqual("", parser.Value().c_str());
            Assert::IsFalse(parser.Error());
            Assert::IsTrue(parser.NextField());
            Assert::AreEqual("", parser.Value().c_str());
            Assert::IsFalse(parser.Error());
            Assert::IsFalse(parser.NextField());
            Assert::IsFalse(parser.Error());
        }

        TEST_METHOD(UnquotedFieldWithSingleEmbeddedQuote_ReturnsFalseWithError)
                    {
            Parser parser(R"(Embedded"Quote)");
            Assert::IsFalse(parser.NextField());
            Assert::IsTrue(parser.Error());
            Assert::IsFalse(parser.NextField());
            Assert::IsTrue(parser.Error());
            Logger::WriteMessage(parser.ErrorMessage().c_str());
        }

        TEST_METHOD(QuotedFieldWithoutTrailingQuote_ReturnsFalseWithError)
                    {
            Parser parser(R"("MissingClosingQuote)");
            Assert::IsFalse(parser.NextField());
            Assert::IsTrue(parser.Error());
            Assert::IsFalse(parser.NextField());
            Assert::IsTrue(parser.Error());
            Logger::WriteMessage(parser.ErrorMessage().c_str());
        }

        //TODO1: Add test methods below and let Copilot generate the code for you.
        //TEST_METHOD(QuotedFieldWithMultipleCommas_ReturnsSingleFieldWithNoError)
        //TEST_METHOD(UnquotedFieldWithEscapedQuote_ReturnsFalseWithError)
        //TEST_METHOD(DoubleQuotedFieldWithEscapedQuote_ReturnsTrueWithoutError)
        //TEST_METHOD(TwoDoubleQuotedFieldWithEscapedQuotes_ReturnsTrueWithoutError)

        //TODO2: Add test methods for additional scenarios below and let Copilot generate the code for you.

    };
}
