# Unity micro-optimizations

This repository includes some micro-optimization experiments I'm doing while programming my game in [Unity](https://unity.com)

### [Variable scope performance](./variable%20scope%20performance/)

![Variable scope performance graph](./variable%20scope%20performance/graph.png)

Experiment driven by the curiosity of understanding whether I should save a lot of class fields in my components, or if it's more performant to locally declare variables that are not meant to be persisted across multiple iteration of the Update/FixedUpdate loop.
