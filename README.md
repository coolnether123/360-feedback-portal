# 360° Feedback Portal

This project implements a 360° Feedback Portal, enabling employees to provide anonymous feedback, managers to view aggregated insights, and administrators to manage users and reporting.

## What it Does

*   **Employee Feedback:** Employees can submit anonymous "kudos" or constructive feedback to their peers.
*   **Manager Dashboards:** Managers gain access to dashboards displaying aggregated feedback, response rates, and trends over time.
*   **Admin Panel:** Administrators can invite users, assign review cycles, and export comprehensive reports.

## Technical Stack & Architecture

The application is built with a modern, containerized architecture, leveraging Google Cloud for deployment.

| Layer         | Technology                               |
| :------------ | :--------------------------------------- |
| **Front-end** | Angular (components, reactive forms, routing, Material Design) |
| **Back-end API** | C# / .NET Core Web API                   |
| **Database**  | MongoDB (hosted in Atlas)                |
| **Hosting / CI-CD** | Google Cloud (Cloud Run, Cloud Build)    |
| **Containerization** | Docker                                   |

### Key Endpoints (Backend)

*   `POST /api/auth/login`: Authenticates users and returns a JWT.
*   `POST /api/auth/register`: Registers new users.
*   `GET /api/feedback`: Retrieves all feedback entries for the current user.
*   `POST /api/feedback`: Inserts new feedback documents into MongoDB.
*   `GET /api/analytics`: Returns aggregated feedback data (counts, averages, time-series).
*   `GET/POST /api/admin/users`, `/api/admin/cycles`: Endpoints for administrative tasks.

## User-facing Flows & Views

*   **Public Landing & Sign-Up (`/`)**: Presents company branding, project overview, and a "Sign up" option.
*   **Login (`/login`)**: Secure user authentication. Redirects to `/dashboard` on success.
*   **Feedback Submission (`/give-feedback`)**: Allows users to select a peer and submit structured feedback (what went well, what could improve, star-rating).
*   **Dashboard / Analytics (`/dashboard`)**: Displays aggregated feedback metrics, charts (e.g., feedback per week, sentiment breakdown), and filtering options.
*   **Admin Panel (`/admin`)**: Accessible only to administrators, providing tools for user management, review cycle administration, and report exports.

## Deployment & CI/CD (Google Cloud)

The project utilizes Google Cloud for automated deployment:

*   **Cloud Build Trigger**: Automatically initiates a build and deployment pipeline on pushes to the main branch.
*   **Docker Images**: Both front-end and back-end applications are containerized.
*   **Cloud Run**: Services are deployed as managed containers on Cloud Run, providing scalability and serverless operation.
*   **Secret Management**: Sensitive information like the MongoDB connection string is securely managed via Google Cloud Secret Manager and injected into the backend service during deployment.

## Automated Testing

*   **Unit Tests**: Implemented for both front-end (Angular: Jasmine/Karma or Jest) and back-end (.NET: xUnit, Moq).
*   **End-to-End (E2E) Tests**: Cypress is used to test critical user flows (e.g., user login, feedback submission, dashboard updates, admin actions).

## UX & Styling

*   **Design System**: Leverages Angular Material for a modern and consistent UI/UX.
*   **Responsiveness**: Designed with a mobile-first approach, adapting layouts for various screen sizes.
*   **Branding**: Customizable with project-specific logos and color palettes using SCSS variables.
*   **Accessibility**: Focus on ARIA labels, keyboard navigation, and inclusive design principles.

## Local Development

### Prerequisites

*   Node.js (v20+) & npm
*   Angular CLI
*   .NET SDK (v8.0+)
*   Docker

### Running the Backend

1.  **Set MongoDB Connection String**: Before running, set the `MONGO_CONNECTION_STRING` environment variable in your terminal:
    *   **Windows (Command Prompt):**
        ```cmd
        set MONGO_CONNECTION_STRING="mongodb+srv://<username>:<password>@<cluster-address>/<database-name>?retryWrites=true&w=majority&appName=360Feedback"
        ```
    *   **Windows (PowerShell):**
        ```powershell
        $env:MONGO_CONNECTION_STRING="mongodb+srv://<username>:<password>@<cluster-address>/<database-name>?retryWrites=true&w=majority&appName=360Feedback"
        ```
    *   **Linux/macOS:**
        ```bash
        export MONGO_CONNECTION_STRING="mongodb+srv://<username>:<password>@<cluster-address>/<database-name>?retryWrites=true&w=majority&appName=360Feedback"
        ```
    Replace `<username>`, `<password>`, `<cluster-address>`, and `<database-name>` with your actual MongoDB Atlas details.

2.  **Run the Backend API**: Navigate to the `backend` directory and run:
    ```bash
    dotnet run
    ```
    The API will typically run on `http://localhost:5153` (HTTP) and `https://localhost:7273` (HTTPS).

### Running the Frontend

1.  **Install Dependencies**: Navigate to the project root and run:
    ```bash
    npm install
    ```
2.  **Start Development Server**: Run the Angular development server:
    ```bash
    ng serve --proxy-config proxy.conf.json
    ```
    This will start the frontend on `http://localhost:4200` and proxy API requests to your running backend.

## Building for Production

To build the Angular project for production:

```bash
ng build --configuration production
```

This will compile your project and place the optimized build artifacts in the `dist/` directory.

## Further Help

For more information on using the Angular CLI, refer to the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) and [Angular Documentation](https://angular.dev/docs).