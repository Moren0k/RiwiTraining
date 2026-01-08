const baseUrl = "http://localhost:5009"; // ajustar al puerto de la API
const output = document.getElementById("output");

// ===== UTIL =====
function print(data) {
  output.textContent = JSON.stringify(data, null, 2);
}

// ===== PRODUCTS =====
async function getProducts() {
  const res = await fetch(`${baseUrl}/getProduct`);
  print(await res.json());
}

async function addProduct() {
  const product = {
    name: document.getElementById("productName").value,
    description: document.getElementById("productDescription").value,
    price: parseFloat(document.getElementById("productPrice").value)
  };
  const res = await fetch(`${baseUrl}/addProduct`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(product)
  });
  print(await res.json());
}

async function updateProduct() {
  const product = {
    id: parseInt(document.getElementById("productId").value),
    name: document.getElementById("productName").value,
    description: document.getElementById("productDescription").value,
    price: parseFloat(document.getElementById("productPrice").value)
  };
  const res = await fetch(`${baseUrl}/updateProduct/${product.id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(product)
  });
  print(await res.json());
}

async function deleteProduct() {
  const id = document.getElementById("productId").value;
  const res = await fetch(`${baseUrl}/deleteProduct/${id}`, { method: "DELETE" });
  print(await res.json());
}

// ===== CUSTOMERS =====
async function getCustomers() {
  const res = await fetch(`${baseUrl}/getCustomer`);
  print(await res.json());
}

async function addCustomer() {
  const customer = {
    name: document.getElementById("customerName").value,
    lastName: document.getElementById("customerLastName").value,
    email: document.getElementById("customerEmail").value
  };
  const res = await fetch(`${baseUrl}/addCustomer`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(customer)
  });
  print(await res.json());
}

async function updateCustomer() {
  const customer = {
    id: parseInt(document.getElementById("customerId").value),
    name: document.getElementById("customerName").value,
    email: document.getElementById("customerEmail").value
  };
  const res = await fetch(`${baseUrl}/updateCustomer/${customer.id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(customer)
  });
  print(await res.json());
}

async function deleteCustomer() {
  const id = document.getElementById("customerId").value;
  const res = await fetch(`${baseUrl}/deleteCustomer/${id}`, { method: "DELETE" });
  print(await res.json());
}
