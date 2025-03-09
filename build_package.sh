#!/usr/bin/env nix-shell
#!nix-shell -i bash -p jq p7zip
set -eu
################################
# VPM Package Builder          #
# v1.1.0                       #
################################
################################
# Settings                     #
################################
PKG_ID=dev.ms0503.mini-ben
PKG_NAME=MiniBen
################################
# End Settings                 #
################################
BASE_DIR=$(dirname "$(realpath "$0")")
PKG_DIR=$BASE_DIR/Assets/$PKG_NAME
OUT_DIR=$BASE_DIR/out
VERSION=$(jq -r .version "$PKG_DIR/package.json")
OUT_FILE=$OUT_DIR/$PKG_ID-$VERSION.zip
mkdir -p "$OUT_DIR"
cd "$BASE_DIR"
cp LICENSE.md README.md "$PKG_DIR"
cd "$PKG_DIR"
rm -f "$OUT_FILE"
7z a -r "$OUT_FILE" ./*
