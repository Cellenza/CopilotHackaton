module;
#include <string>

export module Lexer;

// RFC 4180: https://tools.ietf.org/html/rfc4180

export class Lexer
{
public:
    enum class Token
    {
        EndOfLine,
        FieldSeparator,
        DoubleQuote,
        Value,
    };

    Lexer(std::string_view line)
        : _line(line)
    {
        _value.reserve(_line.size());
    }

    Token NextToken()
    {
        if (_pos >= _line.size())
            return Token::EndOfLine;

        char c = _line[_pos++];

        if (c == ',')
            return Token::FieldSeparator;

        if (c == '"')
            return Token::DoubleQuote;

        _value = c;
        while ((_pos < _line.size()) && (_line[_pos] != ',') && (_line[_pos] != '"'))
        {
            _value += _line[_pos++];
        }

        return Token::Value;
    }

    const std::string& GetValue() const
    {
        return _value;
    }


private:
    std::string_view _line;
    std::string _value;
    size_t _pos = 0;
};