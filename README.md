# Sprint 17. Testing the OrderSystem Project

---

Develop a test project to verify the functionality of the `OrderSystem` application. The tests should cover the following components:
1. `ProductController` for CRUD operations.
2. `CategoryController` for sorting and retrieving categories.
3. `OrderController` for order-related actions.

#### Task Requirements

1. **Setup the Test Project**
   - Create a new test project in the solution. Name it `OrderSystemTests`.
   - Configure the test project to use **NUnit** as the testing framework.
   - Add dependencies for **Moq** (for mocking) and **Entity Framework Core InMemory** (for simulating database interactions).

2. **Test Categories**
   - Write unit tests for the `CategoryController`.

3. **Test Products**
   - Write unit tests for `ProductController` and its actions, such as `Index`, `Create`, and `Details`.

4. **Test Orders**
   - Add unit tests for `OrderController`, covering order creation and listing.

5. **General Requirements**
   - Ensure each test verifies expected behavior.
   - Use mocking where dependencies are not easily isolated (such as database contexts or external services).
   - Make sure to include assertions to verify the outcome of each action.

---

### Instructions for Each Testing Task

#### 1. Set Up and Configure Mocks

1. **Database Context**:
   - Use the **InMemory database** feature in Entity Framework Core to simulate a database. This will allow you to perform operations on a database without requiring a physical database.
   - Set up the InMemory database within each test to ensure isolation between tests.

2. **Mocking Services**:
   - Use **Moq** to mock `IProductService` interface. These mock will allow you to control the behavior of dependencies and focus tests on specific units.

#### 2. Testing ProductController

**Tasks**:
- Write tests for `Index`, `Create`, and `Details` actions in `ProductController`.

**Test Scenarios**:
1. **Index Action**:
   - Verify that `Index` returns a view with the expected list of products.
   - Mock `IProductService` to return a sample list of products.
   - Assert that the returned view model contains the expected data.

2. **Create Action**:
   - Test both `GET` and `POST` versions of the `Create` action.
   - For `POST`, validate that the action adds a new product when `ModelState` is valid.
   - Verify redirection to the `Index` action after a successful creation.
   - Ensure that if `ModelState` is invalid, the view is reloaded with the provided model data.

3. **Details Action**:
   - Test that `Details` returns the expected product when given a valid product ID.
   - Mock `IProductService` to return `null` for non-existing IDs and verify that the action returns `NotFound`.

#### 3. Testing CategoryController

**Tasks**:
- Test `CategoryController`.

**Test Scenarios**:
1. **Index Action**:
   - Test that categories are returned in ascending order by name when `sortOrder` is not specified.
   - Verify that the categories are returned in descending order when `sortOrder` is `"name_desc"`.
   - Use the InMemory database to seed categories for testing purposes.


#### 4. Testing OrderController

**Tasks**:
- Write tests for `Create` in `OrderController`.

**Test Scenarios**:
1. **Create (GET)**:
   - Verify that the `Create` view is returned with the list of products in the dropdown.

2. **Create (POST)**:
   - Test that the order is successfully added when `ModelState` is valid.
   - Use Moq to mock dependencies and simulate expected behavior.

---

### Additional Instructions 

1. **Mocking**:
   - Use Moq for creating mock of service (e.g., `IProductService`).
   - Configure mock to return specific data needed for each test scenario.

2. **Test Isolation**:
   - Use the InMemory database to isolate database tests and avoid side effects across tests.

3. **Assertions**:
   - Ensure assertions are meaningful and validate the expected outcomes.
   - Test both positive and negative scenarios (e.g., valid and invalid inputs).

### Expected Outcomes

- Comprehensive test coverage for the primary actions and methods in `ProductController`, `CategoryController`, and `OrderController`.
- Demonstrated usage of dependency injection, mocking, and assertions to verify application behavior.  
