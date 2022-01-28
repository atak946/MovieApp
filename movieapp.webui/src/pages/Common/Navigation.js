import { useState } from "react";
import { Collapse, Nav, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from "reactstrap";
import Auth from "../../library/Auth/Auth";
import "./Navigation.css";

function Navigation() {

    const [isLoggedIn, setIsLoggedIn] = useState(Auth.IsLoggedIn());

    setInterval(() => {
        setIsLoggedIn(Auth.IsLoggedIn());
    }, 500);

    if (isLoggedIn === true) {
        return (
            <div>
                <Navbar color="light" expand="md" light>
                    <NavbarBrand href="/">
                        MovieApp
                    </NavbarBrand>
                    <NavbarToggler onClick={function noRefCheck() { }} />
                    <Collapse navbar>
                        <Nav className="me-auto" navbar>
                            <NavItem>
                                <NavLink href="/">Anasayfa</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink href="/topmovies">Top 10</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink href="/recommended">Önerilen Filmler</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink href="/upcoming">Yakında Eklenecek Filmler</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink href="/profile">Profil</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink href="/logout">Çıkış</NavLink>
                            </NavItem>
                        </Nav>
                    </Collapse>
                </Navbar>
            </div>
        );
    }
    else
        return (<></>);
}

export default Navigation;