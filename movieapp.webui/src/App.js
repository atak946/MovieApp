import {
  Routes,
  Route,
  BrowserRouter,
  Navigate
} from "react-router-dom";
import Auth from './library/Auth/Auth';
import Login from './pages/Account/Login';
import Index from './pages/Index';
import Navigation from "./pages/Common/Navigation";
import TopMovies from "./pages/Movies/TopMovies";
import { Container } from "reactstrap";
import RecommendedMovies from "./pages/Movies/RecommendedMovies";
import UpcomingMovies from "./pages/Movies/UpcomingMovies";
import Movie from "./pages/Movies/Movie";
import Profile from "./pages/Account/Profile";
import Register from "./pages/Account/Register";

function App() {

  return (
    <BrowserRouter>
      <Navigation />

      <Container fluid>
        <Routes>
          <Route path="/" element={<RequireAuth redirectTo="/login"><Index index exact /></RequireAuth>} />
          <Route path="/topmovies" element={<RequireAuth redirectTo="/login"><TopMovies /></RequireAuth>} />
          <Route path="/recommended" element={<RequireAuth redirectTo="/login"><RecommendedMovies /></RequireAuth>}/>
          <Route path="/upcoming" element={<RequireAuth redirectTo="/login"><UpcomingMovies /></RequireAuth>}/>
          <Route path="/movie/:id" element={<RequireAuth redirectTo="/login"><Movie /></RequireAuth>}/>
          <Route path="/profile" element={<RequireAuth redirectTo="/login"><Profile /></RequireAuth>}/>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/logout" element={<Logout redirectTo="/login" />} />
        </Routes>
      </Container>
    </BrowserRouter>
  );
}

function RequireAuth({ children, redirectTo }) {
  var isLoggedIn = Auth.IsLoggedIn();
  return isLoggedIn ? children : <Navigate to={redirectTo} />;
}

function Logout({ redirectTo }) {
  Auth.Logout();

  return <Navigate to={redirectTo} />;
}

export default App;
