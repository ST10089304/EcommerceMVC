If the API is unavailable, the repository falls back to a hardcoded list of products automatically.

---

## Design Decisions

- **Singleton services** — `ProductRepository` and `OrderService` registered as singletons to maintain in-memory state across requests
- **Static cart** — Held in a static field for simplicity within the academic scope of this project
- **CSS custom properties** — Color palette defined in `:root` for easy theming
- **No Entity Framework** — Deliberately avoided to keep focus on MVC structure and separation of concerns

---

## Known Limitations

- Cart state is shared across all users in the same process
- No user authentication or authorization
- Orders are lost on application restart
- No input validation beyond ASP.NET Core defaults

---




