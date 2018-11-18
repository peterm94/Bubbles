sampler s0;


struct POS_INPUT
{
	float2 TexPos : TEXCOORD0;
};


float4 mainPixel(POS_INPUT input) : COLOR
{
	// Grab the pixel
	float4 color = tex2D(s0, input.TexPos);
	
	// Clip anything with alpha == 0
	clip(color.a == 0 ? -1:1);
	
	// Preserve the alpha and max out RGB to make white
	// We can also max out the alpha if we don't want to preserve transparency
	return float4(color.a, 1, 1, 1);
}


technique SpriteBlink
{
	pass P0
	{
		PixelShader = compile ps_3_0 mainPixel();
	}
};