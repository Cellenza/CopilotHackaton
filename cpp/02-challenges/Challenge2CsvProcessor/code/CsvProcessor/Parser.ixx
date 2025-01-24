module;
#include <string>

export module Parser;
import Lexer;

// RFC 4180: https://tools.ietf.org/html/rfc4180

export class Parser
{
public:
    Parser(std::string_view line)
        : _lexer(line)
    {}

    bool Error() const
    {
        return _error;
    }

    const std::string& ErrorMessage() const
    {
        return _errorMessage;
    }

    const std::string& Value() const
    {
        return _value;
    }

    bool NextField()
    {
        if (_error || _eol)
            return false;

        _value.clear();
        Lexer::Token token = _lexer.NextToken();

        bool inQuote = (token == Lexer::Token::DoubleQuote);
        if (inQuote)
            token = _lexer.NextToken();

        while (true)
        {
            switch (token)
            {
            case Lexer::Token::EndOfLine:
                if (inQuote)
                {
                    _error = true;
                    _errorMessage = "Unexpected end of line while in double-quote";
                    return false;
                }
                else
                {
                    _eol = true;
                    return true;
                }
                break;

            case Lexer::Token::FieldSeparator:
                if (inQuote)
                    _value += ',';
                else
                    return true;
                break;

            case Lexer::Token::DoubleQuote:
                if (inQuote)
                {
                    token = _lexer.NextToken();

                    switch (token)
                    {
                    case Lexer::Token::EndOfLine: 
                        _eol = true;
                        return true; // Found closing double-quote for the field.

                    case Lexer::Token::FieldSeparator:
                        return true; // Found closing double-quote for the field.

                    case Lexer::Token::DoubleQuote:
                        _value += '"'; // Escaped double-quote.
                        break;

                    case Lexer::Token::Value:
                        _error = true;
                        _errorMessage = "Closing double-quote must be followed by field separator";
                        return false;
                    
                    default:
                        _error = true;
                        _errorMessage = "Internal error: unexpected token";
                        return false;
                    }
                }
                else
                {   // Escaped double-quotes are allowed only inside double-quoted fields.
                    _error = true;
                    _errorMessage = "Unexpected double-quote";
                    return false;
                }
                break;

                case Lexer::Token::Value:
                    _value += _lexer.GetValue();
                    break;

                default:
                    _error = true;
                    _errorMessage = "Internal error: unexpected token";
                    return false;
            }

            token = _lexer.NextToken();
        }

        return true;
    }


private:
    Lexer _lexer;
    bool _error = false;
    bool _eol = false;
    std::string _errorMessage;
    std::string _value;
};