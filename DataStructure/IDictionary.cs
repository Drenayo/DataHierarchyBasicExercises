using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    interface IDictionary<Key, Value>
    {
        // 添加一个键值对
        void Add(Key key, Value value);
        // 根据键删除一个键值对
        void Remove(Key key);
        // 根据键查找一个键值对
        bool ContainsKey(Key key);
        // 根据键修改值
        void SetValue(Key key, Value newValue);
        // 根据键得到值
        Value GetValue(Key key);

        int Count { get; }
        bool IsEmpty { get; }
    }
}
