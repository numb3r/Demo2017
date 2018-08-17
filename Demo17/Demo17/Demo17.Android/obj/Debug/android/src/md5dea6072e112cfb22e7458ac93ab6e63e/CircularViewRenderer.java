package md5dea6072e112cfb22e7458ac93ab6e63e;


public class CircularViewRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Demo17.Droid.Renderers.CircularViewRenderer, Demo17.Android", CircularViewRenderer.class, __md_methods);
	}


	public CircularViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CircularViewRenderer.class)
			mono.android.TypeManager.Activate ("Demo17.Droid.Renderers.CircularViewRenderer, Demo17.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CircularViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CircularViewRenderer.class)
			mono.android.TypeManager.Activate ("Demo17.Droid.Renderers.CircularViewRenderer, Demo17.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CircularViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CircularViewRenderer.class)
			mono.android.TypeManager.Activate ("Demo17.Droid.Renderers.CircularViewRenderer, Demo17.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
