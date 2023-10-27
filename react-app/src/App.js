import "./App.css";
import { Login } from "./Pages/Login";
import { ClientRegistration } from "./Pages/Admin/ClientRegistration";
import { Routes, Route } from "react-router-dom";
import { AdminPage } from "./Pages/Admin/AdminPage";
import { EmployeePage } from "./Pages/Employee/EmployeePage";
import { TrainerPage } from "./Pages/Trainer/TrainerPage";
import { ClientPage } from "./Pages/Client/ClientPage";
import { AllClients } from "./Pages/Admin/AllClients";
import { AllEmployees } from "./Pages/Admin/AllEmployees";
import { AllTrainers } from "./Pages/Admin/AllTrainers";
import { CreateEmployee } from "./Pages/Admin/CreateEmployee";
import { CreateTrainer } from "./Pages/Admin/CreateTrainer";
import { AdminInfo } from "./Pages/Admin/AdminInfo";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/register" element={<ClientRegistration />} />
      <Route path="/administrator/:id" element={<AdminPage />} />
      <Route path="/employee/:id" element={<EmployeePage />} />
      <Route path="/trainer/:id" element={<TrainerPage />} />
      <Route path="/client/:id" element={<ClientPage />} />
      <Route path="/administrator/:id/clients" element={<AllClients />} />
      <Route path="/administrator/:id/employees" element={<AllEmployees />} />
      <Route path="/administrator/:id/trainers" element={<AllTrainers />} />
      <Route
        path="/administrator/:id/create-trainer"
        element={<CreateTrainer />}
      />
      <Route
        path="/administrator/:id/create-employee"
        element={<CreateEmployee />}
      />
      <Route path="/administrator/:id/admin-info" element={<AdminInfo />} />
    </Routes>
  );
}

export default App;
