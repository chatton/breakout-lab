#!/usr/bin/env bash
# Build and run a project on an Android emulator (MAUI only supports Android on Linux).
#
# Usage: ./run-android.sh [project-dir]     (default: template)
#
# Expects a user-local install (override any of these with environment variables):
#   .NET SDK + maui-android workload in ~/.dotnet
#   JDK 17 in ~/.local/share/jdk/jdk-17*
#   Android SDK in ~/Android/Sdk with an AVD named "breakout"
set -euo pipefail

PROJECT="${1:-template}"

export DOTNET_ROOT="${DOTNET_ROOT:-$HOME/.dotnet}"
export ANDROID_HOME="${ANDROID_HOME:-$HOME/Android/Sdk}"
export JAVA_HOME="${JAVA_HOME:-$(ls -d "$HOME"/.local/share/jdk/jdk-17* | head -1)}"
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export PATH="$DOTNET_ROOT:$ANDROID_HOME/platform-tools:$PATH"
AVD="${AVD:-breakout}"

cd "$(dirname "$0")"

if ! adb devices | grep -qE '^emulator-[0-9]+\s+device'; then
    echo "Starting emulator '$AVD'..."
    nohup "$ANDROID_HOME/emulator/emulator" -avd "$AVD" -no-snapshot-save -no-boot-anim \
        >/tmp/breakout-emulator.log 2>&1 &
    adb wait-for-device
    until [ "$(adb shell getprop sys.boot_completed 2>/dev/null | tr -d '\r')" = "1" ]; do
        sleep 2
    done
    echo "Emulator booted."
fi

dotnet build "$PROJECT" -t:Run -f net10.0-android \
    "-p:AndroidSdkDirectory=$ANDROID_HOME" \
    "-p:JavaSdkDirectory=$JAVA_HOME"
