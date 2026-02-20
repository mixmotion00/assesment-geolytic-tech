# Property Valuation System

This repository contains a **React frontend** and a **.NET backend API** for the property valuation system.

---

## 1. Running the Frontend (React)

1. Open the **main folder** in your preferred editor (e.g., VS Code).  
2. Navigate to the frontend folder:

```bash
cd frontend
```
3. Install dependencies:
```bash
npm install
```
4. Start the development server:
```bash
npm run dev
```
5. Open your browser at:
```bash
http://localhost:5173
```

## 2. Running the Backend (.Net API)

1. Open the backend folder in your editor (e.g., VS Code).
2. Navigate to the API project folder:

```bash
cd backend/API
```
3. Build the project to ensure there are no errors:
```bash
dotnet build
```
4. Run the backend API:
```bash
dotnet run
```

The API should now be available at:
```bash
https://localhost:5049
```

## 3. My Quick Assumption

**Property Types are pre-seeded in the database**

• I assumed that property types (e.g., Residential, Commercial, Industrial) already exist in the system and are retrieved via an API endpoint.


**No authentication/authorization required**

• The system is designed as a simplified assessment project. Therefore, I assumed no login or role-based access control was required.


**Single environment configuration**

• I assumed the project runs locally using default development configurations without environment-specific deployment setup.


**Basic validation is sufficient**

• Frontend validation ensures:
• • Property Address: required, 10–200 characters
• • Property Type: required
• • Requested Value: required, numeric, minimum value of 1
• • Remarks: optional, maximum 500 characters


**Backend validation is assumed to mirror these constraints**

No pagination or advanced filtering required

• I assumed listing endpoints return manageable data sizes and do not require pagination or search filtering for this assessment scope.

Single-user workflow

• I assumed there is no concurrency handling or multi-user editing scenario required for this simplified system.



## 4. What I would improve with more time

Adding docker to ease publishing and database managemenet

• To improve the architecture and replace in-memory storage
• The application can be configured to use a real PostgreSQL database via Docker.
• Both frontend and backend can be composed together
• Provide environment configuration management
• Seamless transtion if need to deploy for production
• At later stage, with docker, the app can easily implemented with metric service like prometheus and grafana

Enhance Frontend UI/UX
• Improve overall UI looks
• Optimization using useMemo whenever possible
• Add pagination or filtering for listing valuation requests

Add Unit Testing
• Add unit tests for application services and business logic (xTest)
• Add integration tests for API endpoints (postmen)
• Frontend unit test for interactions (Jest/Vitest)

Code Documentation Improvement
• Add more comprehensive inline documentation for complex logic
• Improve frontend component documentation and prop descriptions
• It make the project more maintainable and easier for team members to understand

Architectural Refinement
• Due to time constraints, the current Clean Architecture layering could be further refined
• Further decoupling of application services from infrastructure concerns
• More consistent dependency flow (ensuring strict inward dependencies only)
• Refactoring duplicated or tightly coupled logic




