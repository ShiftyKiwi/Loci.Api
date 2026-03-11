using Dalamud.Plugin;
using Dalamud.Plugin.Ipc;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace LociApi.Helpers;

/// <summary> Specialized disposable Provider for Funcs. </summary>
public sealed class FuncProvider<TRet> : IDisposable
{
    private ICallGateProvider<TRet>? _provider;

    public FuncProvider(IDalamudPluginInterface pi, string label, Func<TRet> func)
    {
        try
        {
            _provider = pi.GetIpcProvider<TRet>(label);
        }
        catch (Exception e)
        {
            PluginLogHelper.WriteError(pi, $"Error registering IPC Provider for {label}\n{e}");
            _provider = null;
        }

        _provider?.RegisterFunc(func);
    }

    public void Dispose()
    {
        _provider?.UnregisterFunc();
        _provider = null;
        GC.SuppressFinalize(this);
    }

    ~FuncProvider()
    {
        Dispose();
    }
}

/// <inheritdoc cref="FuncProvider{TRet}" />
public sealed class FuncProvider<T1, TRet> : IDisposable
{
    private ICallGateProvider<T1, TRet>? _provider;

    public FuncProvider(IDalamudPluginInterface pi, string label, Func<T1, TRet> func)
    {
        try
        {
            _provider = pi.GetIpcProvider<T1, TRet>(label);
        }
        catch (Exception e)
        {
            PluginLogHelper.WriteError(pi, $"Error registering IPC Provider for {label}\n{e}");
            _provider = null;
        }

        _provider?.RegisterFunc(func);
    }

    public void Dispose()
    {
        _provider?.UnregisterFunc();
        _provider = null;
        GC.SuppressFinalize(this);
    }

    ~FuncProvider()
    {
        Dispose();
    }
}

/// <inheritdoc cref="FuncProvider{TRet}" />
public sealed class FuncProvider<T1, T2, TRet> : IDisposable
{
    private ICallGateProvider<T1, T2, TRet>? _provider;

    public FuncProvider(IDalamudPluginInterface pi, string label, Func<T1, T2, TRet> func)
    {
        try
        {
            _provider = pi.GetIpcProvider<T1, T2, TRet>(label);
        }
        catch (Exception e)
        {
            PluginLogHelper.WriteError(pi, $"Error registering IPC Provider for {label}\n{e}");
            _provider = null;
        }

        _provider?.RegisterFunc(func);
    }

    public void Dispose()
    {
        _provider?.UnregisterFunc();
        _provider = null;
        GC.SuppressFinalize(this);
    }

    ~FuncProvider()
    {
        Dispose();
    }
}

/// <inheritdoc cref="FuncProvider{TRet}" />
public sealed class FuncProvider<T1, T2, T3, TRet> : IDisposable
{
    private ICallGateProvider<T1, T2, T3, TRet>? _provider;

    public FuncProvider(IDalamudPluginInterface pi, string label, Func<T1, T2, T3, TRet> func)
    {
        try
        {
            _provider = pi.GetIpcProvider<T1, T2, T3, TRet>(label);
        }
        catch (Exception e)
        {
            PluginLogHelper.WriteError(pi, $"Error registering IPC Provider for {label}\n{e}");
            _provider = null;
        }

        _provider?.RegisterFunc(func);
    }

    public void Dispose()
    {
        _provider?.UnregisterFunc();
        _provider = null;
        GC.SuppressFinalize(this);
    }

    ~FuncProvider()
    {
        Dispose();
    }
}
