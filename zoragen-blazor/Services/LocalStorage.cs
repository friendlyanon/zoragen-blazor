/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

using System;
using System.Threading.Tasks;
using static Microsoft.JSInterop.JSRuntime;

public class LocalStorage : ILocalStorage
{
    private static string CheckKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            throw new ArgumentNullException(nameof(key), "Key must be a non empty string.");
        }
        return key;
    }

    public Task SetItem(string key, string data) =>
        Current.InvokeAsync<object>("ZoraGen.set", CheckKey(key), data);

    public Task<string> GetItem(string key) =>
        Current.InvokeAsync<string>("ZoraGen.get", CheckKey(key));

    public Task RemoveItem(string key) =>
        Current.InvokeAsync<object>("ZoraGen.rm", CheckKey(key));

    public Task Clear() =>
        Current.InvokeAsync<object>("ZoraGen.clr");

    public Task<int> Length() =>
        Current.InvokeAsync<int>("ZoraGen.len");

    public Task<string> Key(int index) =>
        // ReSharper disable once HeapView.BoxingAllocation
        Current.InvokeAsync<string>("ZoraGen.key", index);
}
