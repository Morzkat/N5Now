import { Outlet, Link } from "react-router-dom";
import N5NowNavbar from "./N5NowNavbar";

const Layout = () => {
  return (
    <>
      <N5NowNavbar />

      <Outlet />
    </>
  )
};

export default Layout;