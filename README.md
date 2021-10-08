# Akihabara

Akihabara is Vignette's pure .NET port of Mediapipe, based on [Junrou Nishida's](https://github.com/homuler) MediaPipeUnity project.

## Getting Started

Almost everything is done via the `setup.py` script, so run this first. This will fetch the Mediapipe source, apply patches and finally compile the glue library + Mediapipe itself in one nifty small library. However, you will still need to do the dotnet side, which is just a matter of `dotnet build` after getting `setup.py` done.

## Prerequisites

- Python 3.9 (We tried it with 3.8 but for some odd reason things were broken for this build. PRs welcome to fix this though!)
- .NET 5.0 or .NET 6.0 LTS
- GCC-9 (GCC-10 also works but not guranteed to work since Mediapipe uses a lot of deprecated syntax).
- CMake (Needed if you wanna compile opencv locally with `setup.py --opencv=cmake`.

