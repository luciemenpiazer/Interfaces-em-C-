# Fase 00: Aquecimento Conceitual

Esta fase é conceitual (sem código) e foca em identificar contratos, implementações e políticas no mundo real.

## Situação 1: Armazenamento de Dados

| Elemento | Descrição |
| :--- | :--- |
| **Objetivo** | Persistir (salvar e recuperar) dados de uma aplicação. |
| **Contrato (O Quê)** | `IRepositorioDeDados` (Define as operações de salvar, buscar, atualizar, deletar - CRUD). |
| **Implementação 1 (Como)** | `RepositorioEmMemoria` (Armazenamento temporário, rápido para testes). |
| **Implementação 2 (Como)** | `RepositorioEmBancoDeDados` (Armazenamento permanente e robusto). |
| **Política Simples** | Na fase de desenvolvimento e testes unitários, usar o `RepositorioEmMemoria`; em produção, usar o `RepositorioEmBancoDeDados`. |

## Situação 2: Consumo de Bebida Quente

| Elemento | Descrição |
| :--- | :--- |
| **Objetivo** | Preparar e servir uma bebida quente para ser consumida imediatamente. |
| **Contrato (O Quê)** | `IPreparadorDeBebida` (Define a capacidade de receber insumos, aquecer e servir). |
| **Implementação 1 (Como)** | `CafeteiraExpresso` (Foca em sabor concentrado e serviço rápido, usando pó e água). |
| **Implementação 2 (Como)** | `ChaleiraEletrica` (Foca apenas em aquecer a água de forma eficiente, para ser usada com sachê de chá ou café solúvel). |
| **Política Simples** | Durante a manhã, usar a `CafeteiraExpresso` para um café forte; à noite, usar a `ChaleiraEletrica` para preparar um chá de camomila. |