/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

using System.Threading.Tasks;

public interface ILocalStorage
{
    Task SetItem(string key, string data);
    Task<string> GetItem(string key);
    Task RemoveItem(string key);
    Task Clear();
    Task<int> Length();
    Task<string> Key(int index);
}
