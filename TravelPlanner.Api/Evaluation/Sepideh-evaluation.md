# Evaluation - Sepideh

## AI Quality

The AI model effectively generated customized travel itineraries and structured recommendations by processing user-defined criteria such as budget, trip duration, and specific departure dates.

During our testing phase, a noticeable constraint was the model's tendency to anchor estimated costs around a 5000 SEK baseline, regardless of much higher user budgets. This budget rigidity restricted the diversity of the output, occasionally leading to repetitive destination recommendations and less variety in premium travel options.

---

## Limitations and Risks

- Financial and budget calculations from the AI were not consistently accurate.
- Output formatting and quality were highly sensitive to prompt phrasing.
- External API dependencies introduce risks related to rate limiting (429 errors).
- Potential for minor factual inaccuracies or hallucinations in travel suggestions.

---

## Mitigations

- Implemented strict input validation at the API controller level.
- Configured a global exception handling middleware to catch and process 4xx/5xx errors safely.
- Established request timeout configurations alongside user-friendly error messages.
- Integrated comprehensive AI telemetry and request logging (excluding sensitive headers).
- Enforced a zero-secrets policy in the source code.

---

## Security

The Grok API key is handled securely using Azure Key Vault to prevent exposure.

By leveraging a system-assigned Managed Identity, the live application authenticates and fetches runtime secrets directly from the vault, eliminating the need for hardcoded credentials in the repository or deployment files.

---

## Fullstack Flow

1. The user inputs their specific travel preferences through the frontend UI.
2. The backend receives and thoroughly validates the request payload.
3. The backend forwards the refined payload to the external AI service via a secure HTTP client.
4. The AI returns a structured JSON response containing travel suggestions and quality notes.
5. The backend maps the response and delivers a clean payload back to the frontend for rendering.

---

## Conclusion

This project successfully proves the core competencies of team-based DevOps practices, including AI integration, multi-stage Docker containerization, GitHub Actions CI/CD automation, and secure Azure hosting.

While the AI service showed minor limitations regarding budget variability and repetitive results, the technical fullstack architecture functioned seamlessly end-to-end, serving as a robust baseline for cloud-native deployment.
