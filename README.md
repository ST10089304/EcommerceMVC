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

## Future Improvements

- [ ] Entity Framework Core with SQL Server for persistent storage
- [ ] ASP.NET Core Identity for user authentication
- [ ] Session-based cart per user
- [ ] Product search and category filtering
- [ ] Quantity adjustment and item removal in cart
- [ ] Order history per user
- [ ] Unit tests with xUnit and Moq
- [ ] Docker containerization

---





