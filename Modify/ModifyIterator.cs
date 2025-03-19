using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Modify;

public class ModifyIterator
{
    private readonly StringBuilder _stringBuilder;
    private int _index;

    public ModifyIterator(int index, StringBuilder stringBuilder)
    {
        _index = index;
        _stringBuilder = stringBuilder;
    }

    public string GetCurrentString()
    {
        int index = _index;
        var result = new StringBuilder();

        while (index < _stringBuilder.Length && _stringBuilder[index] != ' ')
        {
            result.Append(_stringBuilder[index]);
            index++;
        }

        return result.ToString();
    }

    public ModifyIterator NextString()
    {
        while (_index < _stringBuilder.Length && _stringBuilder[_index] != ' ')
        {
            _index++;
        }

        _index++;
        return this;
    }
}