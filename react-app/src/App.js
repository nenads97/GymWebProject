import "./App.css";
import { Login } from "./Pages/Login";
import { ClientRegistration } from "./Pages/ClientRegistration";
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
import { CreatePackage } from "./Pages/Admin/CreatePackage";
import { AllPackages } from "./Pages/Admin/AllPackages";
import { SetPackageDiscount } from "./Pages/Admin/SetPackageDiscount";
import { SetPackagePrice } from "./Pages/Admin/SetPackagePrice";
import { DiscountHistory } from "./Pages/Admin/DiscountHistory";
import { PriceHistory } from "./Pages/Admin/PriceHisory";
import { UpdateTrainer } from "./Pages/Admin/UpdateTrainer";
import { UpdateClient } from "./Pages/Admin/UpdateClient";
import { UpdateEmployee } from "./Pages/Admin/UpdateEmployee";
import { CreatePackageDiscount } from "./Pages/Admin/CreatePriceDiscount";
import { EmployeeInfo } from "./Pages/Employee/EmployeeInfo";
import { UpdateClientBalance } from "./Pages/Employee/UpdateBalance";
import { PaymentHistory } from "./Pages/Employee/PaymentHistory";
import { ClientPayments } from "./Pages/Admin/ClientPayments";
import { ClientInfo } from "./Pages/Client/ClientInfo";
import { AllTokens } from "./Pages/Admin/AllTokens";
import { SetTokenPrice } from "./Pages/Admin/SetTokenPrice";
import { TokenPriceHistory } from "./Pages/Admin/TokenPriceHistory";
import { PurchasePackage } from "./Pages/Client/PurchasePackage";
import { UpdateInfo } from "./Pages/Client/UpdateInfo";
import { PurchaseTokens } from "./Pages/Client/PurchaseTokens";
import { SetPackageTokens } from "./Pages/Admin/SetPackageTokens";
import { CreateGroupTraining } from "./Pages/Trainer/CreateGroupTraining";
import { ClientPersonalTrainings } from "./Pages/Client/ClientPersonalTrainings";
import { ClientPersonalTrainingRequests } from "./Pages/Client/ClientPersonalTrainingRequests";
import { PreviewRequests } from "./Pages/Trainer/PreviewRequests";

// import Layout from "./Components/Layout";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/registration" element={<ClientRegistration />} />
      <Route path="/administrator/:id" element={<AdminPage />} />
      <Route path="/employee/:id" element={<EmployeePage />} />
      <Route path="/trainer/:id" element={<TrainerPage />} />
      <Route path="/client/:id" element={<ClientPage />} />
      <Route path="/administrator/:id/clients" element={<AllClients />} />
      <Route path="/administrator/:id/employees" element={<AllEmployees />} />
      <Route path="/administrator/:id/trainers" element={<AllTrainers />} />
      <Route path="/administrator/:id/tokens" element={<AllTokens />} />
      <Route
        path="/administrator/:id/create-trainer"
        element={<CreateTrainer />}
      />
      <Route
        path="/administrator/:id/create-employee"
        element={<CreateEmployee />}
      />
      <Route
        path="/administrator/:id/create-package"
        element={<CreatePackage />}
      />
      <Route path="/administrator/:id/admin-info" element={<AdminInfo />} />
      <Route path="/administrator/:id/all-packages" element={<AllPackages />} />
      <Route
        path="/administrator/:id/set-package-discount"
        element={<SetPackageDiscount />}
      />
      <Route
        path="/administrator/:id/create-package-discount"
        element={<CreatePackageDiscount />}
      />
      <Route
        path="/administrator/:id/set-package-price"
        element={<SetPackagePrice />}
      />
      <Route
        path="/administrator/:id/set-package-tokens"
        element={<SetPackageTokens />}
      />
      <Route
        path="/administrator/:id/set-token-price"
        element={<SetTokenPrice />}
      />
      <Route
        path="/administrator/:id/discount-history"
        element={<DiscountHistory />}
      />
      <Route
        path="/administrator/:id/price-history"
        element={<PriceHistory />}
      />
      <Route
        path="/administrator/:id/payment-history"
        element={<ClientPayments />}
      />
      <Route
        path="/administrator/:id/token-price-history"
        element={<TokenPriceHistory />}
      />
      <Route
        path="/administrator/:id/update-trainer/:trainerId"
        element={<UpdateTrainer />}
      />
      <Route
        path="/administrator/:id/update-client/:clientId"
        element={<UpdateClient />}
      />
      <Route
        path="/administrator/:id/update-employee/:employeeId"
        element={<UpdateEmployee />}
      />
      <Route
        path="/employee/:id/employee-info"
        element={<EmployeeInfo />}
      ></Route>
      <Route
        path="/employee/:id/update-client-balance/:clientId"
        element={<UpdateClientBalance />}
      ></Route>
      <Route
        path="/employee/:id/purchase-tokens"
        element={<PurchaseTokens />}
      ></Route>

      <Route path="/client/:id/client-info" element={<ClientInfo />}></Route>

      <Route
        path="/client/:id/purchase-package"
        element={<PurchasePackage />}
      ></Route>

      <Route path="/client/:id/update-info" element={<UpdateInfo />}></Route>

      <Route
        path="/client/:id/personal-trainings"
        element={<ClientPersonalTrainings />}
      ></Route>

      <Route
        path="/client/:id/personal-training-requests"
        element={<ClientPersonalTrainingRequests />}
      ></Route>

      <Route
        path="/trainer/:id/create-group-training"
        element={<CreateGroupTraining />}
      ></Route>

      <Route
        path="/trainer/:id/preview-requests"
        element={<PreviewRequests />}
      ></Route>
    </Routes>
  );
}

export default App;
