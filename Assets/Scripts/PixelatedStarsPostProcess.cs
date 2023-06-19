using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PixelatedStarsPostProcess : MonoBehaviour
{
    public Material material;
    public float speed = 1f;
    public float starSize = 5f;
    public float brightness = 1f;

    private PixelatedStarsPass pixelatedStarsPass;

    private void OnEnable()
    {
        pixelatedStarsPass = new PixelatedStarsPass(material, speed, starSize, brightness);
        RenderPipelineManager.beginCameraRendering += ExecutePixelatedStarsPass;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= ExecutePixelatedStarsPass;
    }

    private void ExecutePixelatedStarsPass(ScriptableRenderContext context, Camera camera)
    {
        RenderingData renderingData = new RenderingData();
        pixelatedStarsPass.Execute(context, ref renderingData);
    }

    private class PixelatedStarsPass : ScriptableRenderPass
    {
        private Material material;
        private float speed;
        private float starSize;
        private float brightness;

        public PixelatedStarsPass(Material material, float speed, float starSize, float brightness)
        {
            this.material = material;
            this.speed = speed;
            this.starSize = starSize;
            this.brightness = brightness;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null)
                return;

            CommandBuffer cmd = CommandBufferPool.Get("Pixelated Stars");
            RenderTargetIdentifier source = renderingData.cameraData.renderer.cameraColorTarget;
            RenderTargetIdentifier destination = RenderTargetHandle.CameraTarget.Identifier();

            cmd.Blit(source, destination, material);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}
