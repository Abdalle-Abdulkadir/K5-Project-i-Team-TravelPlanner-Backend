# Evaluation

## AI Quality

The AI generated relevant travel suggestions and complete travel plans based on the user's budget, travel duration, and departure date.

One limitation observed during testing was that the estimated cost often remained close to 5000 SEK, even when significantly higher budgets were provided. This sometimes resulted in repetitive destination suggestions and reduced variation in the generated travel plans.

---

## Limitations and Risks

- Budget estimates were not always accurate.
- Responses could vary depending on the prompt.
- AI services may be affected by rate limits.
- Generated information may occasionally be inaccurate.

---

## Mitigations

- Input validation for all user inputs.
- Global exception handling through middleware.
- Timeout handling and clear error messages.
- AI request logging.
- No secrets stored in source code.

---

## Security

Azure Key Vault stores the Grok API key securely.

Managed Identity allows the application to access secrets without storing credentials in the application or repository.

---

## Fullstack Flow

1. User submits travel preferences in the frontend.
2. Backend validates the request.
3. Backend sends the request to the AI service.
4. AI generates travel recommendations.
5. Backend returns the result to the frontend.

---

## Conclusion

The project successfully demonstrates AI integration, automated testing, Docker containerization, CI/CD automation, and secure Azure deployment.

Although the AI occasionally produced repetitive results and inaccurate budget estimations, the application worked as expected and provides a solid foundation for future improvements and further development.
