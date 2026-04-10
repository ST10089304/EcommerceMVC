# EcommerceMVC

A full-featured e-commerce web application built with **ASP.NET Core MVC (.NET 8)**, converted from a Console Application as part of an academic exercise in software architecture and MVC design patterns.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Integration](#api-integration)
- [Design Decisions](#design-decisions)
- [Known Limitations](#known-limitations)
- [Future Improvements](#future-improvements)

---

## Overview

This project demonstrates the conversion of a C# Console Application into a structured **ASP.NET Core MVC** web application. The original console app implemented a basic e-commerce flow — product listing, cart management, and order placement — using in-memory data structures.

The MVC version retains all original business logic while introducing a proper separation of concerns, HTTP request handling, Razor view rendering, and integration with an external REST API ([DummyJSON](https://dummyjson.com)) for realistic product data.

---

## Architecture
