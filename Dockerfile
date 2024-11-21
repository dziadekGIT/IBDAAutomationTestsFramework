FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY IBDA_automationTests.sln ./

COPY IBDA_automationTests/IBDA_automationTests.csproj ./IBDA_automationTests/

RUN dotnet restore

COPY . .

RUN dotnet publish IBDA_automationTests.sln -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY IBDA_automationTests.sln ./
COPY IBDA_automationTests ./IBDA_automationTests

COPY --from=build /app/out .

RUN apt-get update && apt-get install -y \
    wget gnupg unzip curl ca-certificates fonts-liberation \
    libappindicator3-1 libasound2 libgbm1 libgtk-3-0 libx11-xcb1 \
    xdg-utils libnss3 libxss1 libgconf-2-4 --no-install-recommends 

RUN wget -q -O google-chrome.deb https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb \
    && dpkg -i google-chrome.deb || apt-get install -f -y \
    && rm google-chrome.deb 

RUN CHROMEDRIVER_VERSION=$(curl -s https://chromedriver.storage.googleapis.com/LATEST_RELEASE) \
    && wget -q https://chromedriver.storage.googleapis.com/${CHROMEDRIVER_VERSION}/chromedriver_linux64.zip \
    && unzip chromedriver_linux64.zip -d /usr/local/bin \
    && chmod +x /usr/local/bin/chromedriver \
    && rm chromedriver_linux64.zip

ENV DOTNET_EnableDiagnostics=0

EXPOSE 5000
CMD ["tail", "-f", "/dev/null"]
