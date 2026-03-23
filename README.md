# Shaders Tutorial: Learning Shaders in Unity

This project is a comprehensive tutorial and sandbox for learning advanced shader techniques in Unity. It explores various aspects of the rendering pipeline, from basic texture splatting to a custom deferred shading system with PBR (Physically Based Rendering) support.

## Project Structure

The project is organized into `Assets/Shaders` and `Assets/Scripts`, focusing on providing a clear implementation of complex lighting and shading concepts.

### Shader Overview

| Shader File | Description |
| :--- | :--- |
| **LightingShader.shader** | The main feature-rich PBR shader. Supports Forward Base, Forward Add, Deferred, Shadow Caster, and Meta passes. Handles metallic maps, smoothness, normal mapping, emission, and occlusion. |
| **DeferredShading.shader** | A custom implementation of the deferred shading light accumulation pass, using G-buffer data to calculate light contributions. |
| **DeferredFog.shader** | A post-processing shader for applying distance-based fog in a deferred rendering pipeline. |
| **TextureSplatting.shader** | Demonstrates texture blending using a splat map (RGB control texture) to mix up to four different terrain textures. |
| **TestShader.shader** | A basic utility shader for simple texture tiling and tinting tests. |

### Include Files (.cginc)

These files encapsulate the core logic used across various shaders to ensure modularity and reuse. They have been mathematically verified to align with industry standards:

- **MyPBRLighting.cginc**: The central PBR lighting model. It implements **Unity's Standard PBR (GGX/Smith)**, including proper premultiplied alpha for transparency and LDR logarithmic encoding for deferred passes.
- **My Shadows.cginc**: Logic for shadow casting. Implements standard depth encoding for cube maps (point lights) and uses **dithered transparency masks** for semitransparent shadows.
- **MyDeferredShading.cginc**: Core light calculation logic for the custom deferred shading pass. Correctness of **world-space position reconstruction** from depth buffers has been verified.
- **MyLightmapping.cginc**: Meta pass logic for Unity's lightmapper. Implements Specular-to-Albedo boost for physically accurate GI baking of metallic surfaces.

### Core Scripts

- **DeferredFogEffect.cs**: Manages the post-processing camera effect for deferred fog, calculating frustum corners and applying the `DeferredFog.shader`.
- **MyLightingShaderGUI.cs**: A custom editor script providing a clean, organized inspector interface for the `LightingShader`.
- **TangentSpaceVisualizer.cs**: A debugging tool to visualize mesh tangents and bitangents in the editor.

## Getting Started

1. Open the `SampleScene.unity` in the `Assets/Scenes` folder.
2. Observe the different objects showing off various shader features (PBR, Splatting, etc.).
3. Examine the `Main Camera` for the `Deferred Fog Effect` component.
4. Experiment with the materials using the `Custom/Lighting Shader` to see how different maps and settings affect the final look.

## Key Concepts Explored

- **Physically Based Rendering (PBR)**: Implementing Metallic/Smoothness workflows.
- **Forward vs. Deferred Rendering**: Custom implementations for both pipelines.
- **Shadow Mapping**: Proper shadow casting for directional, point, and spot lights.
- **Custom Post-Processing**: Implementing fog and deferred shading effects.
- **Editor Tooling**: Custom Inspector GUIs for easier material manipulation.
