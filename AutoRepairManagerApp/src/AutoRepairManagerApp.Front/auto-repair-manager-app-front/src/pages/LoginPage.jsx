import React, { useState, useEffect } from "react";

const Profile = () => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUserData = async () => {
      const token = localStorage.getItem("authToken"); // Retrieve token from localStorage

      if (!token) {
        setError("No token found in localStorage");
        setLoading(false);
        return;
      }

      try {
        const response = await fetch(`http://localhost:5271/Identity/User/${token})`, {
          method: "GET"
        });

        if (!response.ok) {
          throw new Error("Failed to fetch data");
        }

        const data = await response.json();

        // Assuming the API returns the user data in this structure
        setUser(data.user); // Update state with the fetched data
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchUserData();
  }, []); // Empty dependency array ensures the effect runs only once after the initial render

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center py-10 px-4">
      <div className="bg-white shadow-md rounded-lg w-full max-w-4xl p-6">
        {/* Profile Header */}
        <div className="flex flex-col md:flex-row items-center justify-between border-b pb-6">
          <div className="flex items-center space-x-4">
            <img
              src={user.Avatar || "https://via.placeholder.com/150"} // Fallback to placeholder if no profile picture
              alt="Profile"
              className="w-24 h-24 rounded-full shadow"
            />
            <div>
              <h1 className="text-2xl font-bold text-gray-800">{user.Name || "John Doe"}</h1>
              {/* <p className="text-sm text-gray-500">{user.jobTitle || "Software Engineer"}</p> */}
            </div>
          </div>
          <button className="mt-4 md:mt-0 px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700">
            Edit Profile
          </button>
        </div>

        {/* Profile Details */}
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mt-6">
          <div>
            <h2 className="text-lg font-semibold text-gray-700">User Details</h2>
            <ul className="mt-4 space-y-2 text-gray-600">
              <li><strong>Name:</strong> {user.Name || "john.doe@example.com"}</li>
              <li><strong>Surname:</strong> {user.Surname || "john.doe@example.com"}</li>
              <li><strong>Email:</strong> {user.Email || "john.doe@example.com"}</li>
              <li><strong>Phone:</strong> {user.phone || "+123 456 7890"}</li>
              {/* <li><strong>Address:</strong> {user.address || "123 Street, City, Country"}</li> */}
              {/* <li><strong>Member Since:</strong> {user. || "January 2023"}</li> */}
            </ul>
          </div>

          {/* Recent Activity */}
          <div>
            <h2 className="text-lg font-semibold text-gray-700">Recent Activity</h2>
            <ul className="mt-4 space-y-2 text-gray-600">
              {user.recentActivity ? (
                user.recentActivity.map((activity, index) => (
                  <li key={index}>✅ {activity}</li>
                ))
              ) : (
                <li>No recent activity</li>
              )}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
